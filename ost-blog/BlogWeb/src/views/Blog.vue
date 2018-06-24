<template>
  <div class="blog">
    <p v-if="isLoading">Loading...</p>
    <md-button class="add-btn md-icon-button md-raised md-primary" @click="showDialog = true">
      <md-icon>add</md-icon>
    </md-button>
    <blog-post class="post" v-if="!isLoading" v-for="post in posts" :key="post.id" v-bind="post"></blog-post>

    <md-dialog class="post-dialog" :md-active.sync="showDialog">
      <md-dialog-title>Add Blog Post</md-dialog-title>

      <form novalidate class="md-layout post-form" @submit.prevent="validatePost">
        <div class="md-layout-item md-small-size-100">
          <md-field :class="getValidationClass('title')">
            <label for="title">Title</label>
            <md-input name="title" id="title" v-model="form.title" :disabled="isSaving" />
            <span class="md-error" v-if="!$v.form.title.required">Title is required</span>
          </md-field>
        </div>
        <div class="md-layout-item md-small-size-100">
          <md-field :class="getValidationClass('image')">
            <label for="image">Image URL</label>
            <md-input name="image" id="image" v-model="form.image" :disabled="isSaving" />
            <span class="md-error" v-if="!$v.form.image.required">Image is required</span>
          </md-field>
        </div>
        <div class="md-layout-item md-small-size-100">
          <md-field :class="getValidationClass('content')">
            <label for="content">Content</label>
            <md-textarea name="content" id="content" v-model="form.content" :disabled="isSaving" />
            <span class="md-error" v-if="!$v.form.content.required">Content is required</span>
          </md-field>
        </div>
        <md-dialog-actions>
          <md-button class="md-primary" @click="clearDialog()">Cancel</md-button>
          <md-button type="submit" class="md-primary" :disabled="isSaving">Save</md-button>
        </md-dialog-actions>
      </form>  
    </md-dialog>
    
  </div>
</template>

<script>
import axios from "axios";
import BlogPost from "@/components/BlogPost.vue";
import { required } from "vuelidate/lib/validators";

export default {
  components: { BlogPost },
  data: () => ({
    posts: [],
    isLoading: true,
    isSaving: false,
    showDialog: false,
    form: {
      title: null,
      image: null,
      content: null
    }
  }),
  validations: {
    form: {
      title: {
        required
      },
      image: {
        required
      },
      content: {
        required
      }
    }
  },
  created() {
    axios
      .get("http://localhost:59661/api/posts")
      .then(response => {
        this.posts = response.data;
        this.isLoading = false;
      })
      .catch(() => {
        this.isLoading = false;
      });
  },
  methods: {
    getValidationClass(fieldName) {
      const field = this.$v.form[fieldName];

      if (field) {
        return {
          "md-invalid": field.$invalid && field.$dirty
        };
      }
    },
    clearDialog() {
      this.$v.$reset();
      this.form.title = null;
      this.form.image = null;
      this.form.content = null;
      this.showDialog = false;
    },
    save() {
      this.isSaving = true;
      axios.post("http://localhost:59661/api/posts", this.form)
        .then(response => {
          this.posts.splice(0, 0, response.data);
          this.isSaving = false;
          this.clearDialog();
        })
        .catch(() => {
          this.isSaving = false;
        });
    },
    validatePost () {
      this.$v.$touch();
      if (!this.$v.$invalid) {
        this.save();
      }
    }
  }
};
</script>

<style scoped>
.blog {
  position: relative;
  margin: 20px 100px 20px 100px;
  display: flex;
  flex-direction: column;
  align-items: center;
}

.add-btn {
  position: absolute;
  right: -50px;
  top: 0;
}

.post {
  margin-bottom: 20px;
}

.post-dialog {
  width: 400px;
}

.post-form {
  display: flex;
  flex-direction: column;
  margin-right: 20px;
  margin-left: 20px;
}
</style>