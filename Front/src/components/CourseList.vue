<template>
  <div class="list row">
    <div class="col-md-9">
      <div class="input-group mb-3">
        <input type="text" class="form-control" placeholder="Search by title"
          v-model="title"/>
        <div class="input-group-append">
          <button class="btn btn-outline-secondary" type="button"
            @click="findCourseByTitle"
          >
            Search
          </button>
          
        </div>
      </div>
      <div class="input-group mb-1">
       
        <div class="input-group-append">
          <button class="btn btn-outline-secondary" type="button"
            @click="retrieveCourses"
          >
            CancelSearch
          </button>
          
        </div>
      </div>
    </div>
    <div class="col-md-6">
      <h4>Courses List</h4>
      <ul class="list-group">
        <li class="list-group-item"
          :class="{ active: courseID == currentIndex }"
          v-for="(Course, courseID) in Courses"
          :key="courseID"
          @click="setActiveCourse(Course, courseID)"
        >
          {{ Course.title }}
        </li>
      </ul>

     
    </div>
    <div class="col-md-6">
      <div v-if="currentCourse">
        <h4>Course</h4>
        <div>
          <label><strong>Title:</strong></label> {{ currentCourse.title }}
        </div>
        <div>
          <label><strong>Credits:</strong></label> {{ currentCourse.credits }}
        </div>

        <router-link :to="'/Courses/' + currentCourse.courseID" class="badge badge-warning">Edit</router-link>
      </div>
      <div v-else>
        <br />
        <p>Please click on a Course...</p>
      </div>
    </div>
  </div>
</template>

<script>
import MyDataService from "../services/MyDataService";

export default {
  name: "courses-list",
  data() {
    return {
      Courses: [],
      currentCourse: null,
      currentIndex: -1,
      title: ""
    };
  },
  methods: {
    retrieveCourses() {
      MyDataService.getCourses()
        .then(response => {
          this.Courses = response.data;
          console.log(response.data);
        })
        .catch(e => {
          console.log(e);
        });
    },

    refreshList() {
      this.retrieveCourses();
      this.currentCourse = null;
      this.currentIndex = -1;
    },

    setActiveCourse(Course, index) {
      this.currentCourse = Course;
      this.currentIndex = index;
    },

    
    findCourseByTitle() {
      MyDataService.findCourseByTitle(this.title)
        .then(response => {
          this.Courses = response.data;
          console.log(response.data);
        })
        .catch(e => {
          console.log(e);
        });
    }
  },
  mounted() {
    this.retrieveCourses();
  }
};
</script>

<style>
.list {
  text-align: left;
  max-width: 800px;
  margin: auto;
}
</style>
