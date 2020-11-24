<template>
  <div class="list row">
    <div class="col-md-9">
      <div class="input-group mb-3">
        <input type="text" class="form-control" placeholder="Search by title"
          v-model="Name"/>
        <div class="input-group-append">
          <button class="btn btn-outline-secondary" type="button"
            @click="findStudentByName"
          >
            Search
          </button>
          
        </div>
      </div>
      <div class="input-group mb-1">
       
        <div class="input-group-append">
          <button class="btn btn-outline-secondary" type="button"
            @click="retrieveStudents"
          >
            CancelSearch
          </button>
          
        </div>
      </div>
    </div>
    <div class="col-md-6">
      <h4>Students List</h4>
      <ul class="list-group">
        <li class="list-group-item"
          :class="{ active: id == currentIndex }"
          v-for="(Student, id) in Students"
          :key="id"
          @click="setActiveStudent(Student, id)"
        >
          {{ Student.firstMidName }}
        </li>
      </ul>

     
    </div>
    <div class="col-md-6">
      <div v-if="currentStudent">
        <h4>Student</h4>
        <div>
          <label><strong>LastName:</strong></label> {{ currentStudent.lastName }}
        </div>
        <div>
          <label><strong>FirstMidName:</strong></label> {{ currentStudent.firstMidName }}
        </div>
         <div>
          <label><strong>Age:</strong></label> {{ currentStudent.age }}
        </div>

        <router-link :to="'/Students/' + currentStudent.id" class="badge badge-warning">Edit</router-link>
      </div>
      <div v-else>
        <br />
        <p>Please click on a Student...</p>
      </div>
    </div>
  </div>
</template>

<script>
import MyDataService from "../services/MyDataService";

export default {
  name: "students-list",
  data() {
    return {
      Students: [],
      currentStudent: null,
      currentIndex: -1,
      Name: ""
    };
  },
  methods: {
    retrieveStudents() {
      MyDataService.getAllStudents()
        .then(response => {
          this.Students = response.data;
          console.log(response.data);
        })
        .catch(e => {
          console.log(e);
        });
    },

    refreshList() {
      this.retrieveStudents();
      this.currentStudent = null;
      this.currentIndex = -1;
    },

    setActiveStudent(Student, index) {
      this.currentStudent = Student;
      this.currentIndex = index;
    },

    
    findStudentByName() {
      MyDataService.findStudentByName(this.Name)
        .then(response => {
          this.Students = response.data;
          console.log(response.data);
        })
        .catch(e => {
          console.log(e);
        });
    }
  },
  mounted() {
    this.retrieveStudents();
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
