<template>
<TheNavigation/>
<div class="container">
      <router-view></router-view>
</div>
</template>

<script>
  import TheNavigation from "./components/TheNavigation.vue"

  export default {
    components:{TheNavigation}
  }

</script>


<style>

*{
  box-sizing: border-box;
}

html {
  font-family: sans-serif;
}

body {
  margin: 0;
  padding: 0;

}

.container {
  max-width: 55rem;
  margin: 0 auto;
  margin-top: 7rem;
}

</style>