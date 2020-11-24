<template>
  <div v-if="currentCourse" class="edit-form">
    <h4>CourseCard</h4>
    <form>
      <div class="form-group">
        <label for="title">title</label>
        <input type="text" class="form-control" id="title"
          v-model="currentCourse.title"
        />
      </div>
      <div class="form-group">
        <label for="credits">Credits</label>
        <input type="number" class="form-control" id="credits"
          v-model="currentCourse.credits"
        />
      </div>
 </form>

    <button class="badge badge-danger mr-2"
      @click="deleteTutorial"
    >
      Delete
    </button>

    <button type="submit" class="badge badge-success"
      @click="updateTutorial"
    >
      Update
    </button>
    <p>{{ message }}</p>
  </div>

  <div v-else>
    <br />
    <p>Please click on a Tutorial...</p>
  </div>
</template>

<script>
import MyDataService from "../services/MyDataService";

export default {
  name: "course",
  data() {
    return {
      currentCourse: null,
      message: ''
    };
  },
  methods: {
    getTutorial(id) {
      MyDataService.getCourseById(id)
        .then(response => {
          this.currentCourse = response.data;
          console.log(response.data);
        })
        .catch(e => {
          console.log(e);
        });
    },

    updatePublished(status) {
      var data = {
        id: this.currentCourse.id,
        title: this.currentCourse.title,
        credits: this.currentCourse.credits,
        published: status
      };

      MyDataService.updateCourses(this.currentCourse.id, data)
        .then(response => {
          this.currentCourse.published = status;
          console.log(response.data);
        })
        .catch(e => {
          console.log(e);
        });
    },

    updateTutorial() {
      MyDataService.updateCourses(this.currentCourse.id, this.currentCourse)
        .then(response => {
          console.log(response.data);
          this.message = 'The tutorial was updated successfully!';
        })
        .catch(e => {
          console.log(e);
        });
    },

    deleteTutorial() {
      MyDataService.deleteCourseById(this.currentCourse.id)
        .then(response => {
          console.log(response.data);
          this.$router.push({ name: "Courses" });
        })
        .catch(e => {
          console.log(e);
        });
    }
  },
  mounted() {
    this.message = '';
    this.getTutorial(this.$route.params.id);
  }
};
</script>


<style>
.edit-form {
  max-width: 300px;
  margin: auto;
}
</style>
