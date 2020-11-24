<template>
  <div v-if="currentStudent" class="edit-form">
    <h4>StudentCard</h4>
    <form>
      <div class="form-group">
        <label for="lastName">lastName</label>
        <input type="text" class="form-control" id="lastName"
          v-model="currentStudent.lastName"
        />
      </div>
      <div class="form-group">
        <label for="firstMidName">FirstName</label>
        <input type="text" class="form-control" id="firstMidName"
          v-model="currentStudent.firstMidName"
        />
      </div>

     <div class="form-group">
        <label for="age">Age</label>
        <input type="number" class="form-control" id="age"
          v-model.number="currentStudent.age"
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
  name: "student",
  data() {
    return {
      currentStudent: null,
      message: ''
    };
  },
  methods: {
    getTutorial(id) {
      MyDataService.getStudentById(id)
        .then(response => {
          this.currentStudent = response.data;
          console.log(response.data);
        })
        .catch(e => {
          console.log(e);
        });
    },

    updatePublished(status) {
      var data = {
        id: this.currentStudent.id,
        lastName: this.currentStudent.lastName,
        firstName: this.currentStudent.firstName,
        age: this.currentStudent.age,
        published: status
      };

      MyDataService.updateStudents(this.currentStudent.id, data)
        .then(response => {
          this.currentStudent.published = status;
          console.log(response.data);
        })
        .catch(e => {
          console.log(e);
        });
    },

    updateTutorial() {
      MyDataService.updateStudents(this.currentStudent.id, this.currentStudent)
        .then(response => {
          console.log(response.data);
          this.message = 'The tutorial was updated successfully!';
        })
        .catch(e => {
          console.log(e);
        });
    },

    deleteTutorial() {
      MyDataService.deleteStudentById(this.currentStudent.id)
        .then(response => {
          console.log(response.data);
          this.$router.push({ name: "students" });
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
