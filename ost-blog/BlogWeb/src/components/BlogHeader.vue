<template>
  <md-toolbar class="header">
    <img style="height: 30px" src="../assets/logo.png">
    <h2 class="md-title">OST</h2>
    <md-tabs md-sync-route class="navigation">
      <md-tab id="tab-home" md-label="Blog" to="/"></md-tab>
      <md-tab id="tab-pages" md-label="About" to="/about"></md-tab>
    </md-tabs>
  </md-toolbar>
</template>

<script>
export default {
  name: "blog-header"
};
</script>

<style scoped>
h2.md-title {
  color: #0070b3;
  font-weight: bold;
}

.router-link-exact-active {
  font-weight: bold;
}

.header >>> .navigation.md-tabs.md-theme-default .md-tabs-navigation {
  background-color: var(--md-theme-default-toolbarvariant, #f5f5f5);
}

</style>
