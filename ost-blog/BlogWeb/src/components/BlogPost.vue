<template>
  <div class="blog-post">
    <md-card>
      <md-card-media>
        <img class="blog-photo" :src="image" alt="People">
      </md-card-media>

      <md-card-header>
        <div class="md-title">{{title}}</div>
        <div class="md-subhead">{{dateCreated | moment("MMMM DD, YYYY")}}</div>
      </md-card-header>

      <md-card-expand>
        <md-card-actions md-alignment="space-between">
          <div>
            <md-button class="md-icon-button">
          <md-icon>favorite</md-icon>
        </md-button>

        <md-button class="md-icon-button">
          <md-icon>bookmark</md-icon>
        </md-button>

        <md-button class="md-icon-button">
          <md-icon>share</md-icon>
        </md-button>
          </div>
          <md-card-expand-trigger>
            <md-button class="md-icon-button">
              <md-icon>keyboard_arrow_down</md-icon>
            </md-button>
          </md-card-expand-trigger>
        </md-card-actions>

        <md-card-expand-content>
          <md-card-content>
            {{ content }}
          </md-card-content>
        </md-card-expand-content>
      </md-card-expand>
    </md-card>
  </div>
</template>

<script>
export default {
  name: "blog-post",
  props: {
    title: String,
    image: String,
    dateCreated: String,
    content: String
  }
};
</script>

<style scoped>
.card-expansion {
  height: 480px;
}

.blog-photo {
  object-fit: cover;
  width: 800px;
  max-height: 200px;
}

.md-card {
  max-width: 800px;
  margin: 4px;
  display: inline-block;
  vertical-align: top;
}

.md-card .md-card-header {
  padding-bottom: 0;
}
</style>
