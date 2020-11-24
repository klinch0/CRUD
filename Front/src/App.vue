<template>
  <div id="app">
    <nav class="navbar navbar-expand navbar-dark bg-dark">
      <router-link to="/" class="navbar-brand">MyTest</router-link>
      <div class="navbar-nav mr-auto">
        <li class="nav-item">
          <router-link to="/students" class="nav-link">Students</router-link>
        </li>
        <li class="nav-item">
          <router-link to="/add" class="nav-link">AddStudent</router-link>
        </li>
        <li class="nav-item">
          <router-link to="/courses" class="nav-link">Courses</router-link>
        </li>
      </div>
    </nav>

    <div class="container mt-3">
      <router-view />
    </div>
  </div>
</template>

<script>
export default {
  name: "app"
};
</script>
