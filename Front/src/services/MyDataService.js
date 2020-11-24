import Axios from "axios";
import http from "../http-common";

class MyDataService {

  //[Students]
  getAllStudents() {
    return http.get("students/");
  }

  getStudentById(id) {
    return http.get(`students/Details/${id}`);
  }

  createStudent(data) {
    return http.post("/students/Create/", data);
  }

  updateStudents(id, data) {
    return http.post(`/students/Edit/`, data);
  }

  deleteStudentById(id) {
    return http.get(`/students/delete/${id}`);
  }

  findStudentByName(firstMidName) {
    return http.get(`/students/StudentsByValue?firstMidName=${firstMidName}`);
  }


  //[Courses]

  getCourses()
  {
    return Axios.get('https://localhost:44373/courses/')
  }
  findCourseByTitle(title) {
    return http.get(`/courses/CoursesByValue?Title=${title}`);
  }
  getCourseById(id) {
    return http.get(`courses/Details/${id}`);
  }
  updateCourses(id, data) {
    return http.post(`/courses/Edit/`, data);
  }
  deleteCourseById(id) {
    return http.get(`/courses/delete/${id}`);
  }
  createCourse(data) {
    return http.post("/courses/Create/", data);
  }  
}

export default new MyDataService();
