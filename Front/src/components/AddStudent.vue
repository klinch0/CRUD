<template>
  <div class="submit-form">
    <div v-if="!submitted">
      <div class="form-group">
        <label for="LastName">LastName</label>
        <input
          type="text"
          class="form-control"
          id="LastName"
          required
          v-model="Student.LastName"
          name="LastName"
        />
      </div>

      <div class="form-group">
        <label for="FirstMidName">FirstMidName</label>
        <input
          class="form-control"
          id="FirstMidName"
          required
          v-model="Student.FirstMidName"
          name="FirstMidName"
        />
      </div>
 <div class="form-group">
        <label for="age">Age</label>
        <input
          class="form-control"
          id="age"
          required
          v-model.number="Student.age"
          name="age"
        />
      </div>
      <button @click="saveStudent" class="btn btn-success">Submit</button>
    </div>

    <div v-else>
      <h4>You submitted successfully!</h4>
      <button class="btn btn-success" @click="newStudent">Add</button>
    </div>
  </div>
</template>

<script>
import MyDataService from "../services/MyDataService";

export default {
  name: "add-student",
  data() {
    return {
      Student: {
        id: null,
        LastName: "",
        FirstMidName: "",
        age:0
       },
      submitted: false
    };
  },
  methods: {
    saveStudent() {
      var data = {
        LastName: this.Student.LastName,
        FirstMidName: this.Student.FirstMidName,
        Age:this.Student.age
      };

      MyDataService.createStudent(data)
        .then(response => {
          this.Student.id = response.data.id;
          console.log(response.data);
           this.submitted = true;
        })
        .catch(e => {
          console.log(e);
        });
    },
    
    newStudent() {
       this.submitted = false;
      this.Student = {};
    }
  }
};
</script>

<style>
.submit-form {
  max-width: 300px;
  margin: auto;
}
</style>
