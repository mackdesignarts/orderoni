<template>
    <section class="section section-shaped section-lg my-0">
        <div class="shape shape-style-1 bg-gradient-default">
            <span></span>
            <span></span>
            <span></span>
            <span></span>
            <span></span>
            <span></span>
            <span></span>
            <span></span>
        </div>
        <div class="container pt-lg-md col-adjust-up">
            <div class="row justify-content-center">
                <div class="col-lg-5">
                    <card type="secondary" shadow
                          header-classes="bg-white pb-5"
                          body-classes="px-lg-5 py-lg-5"
                          class="border-0">
                        <template>
                            <div class="text-left text-muted mb-4 heading-2">
                                <span>Sign in or sign up</span>
                            </div>
                            <div class="login-input-wrapper">
                                <base-input alternative
                                            placeholder="Email"
                                            addon-left-icon="email-icon-class"
                                            v-model="username" 
                                            name="username"
                                            >
                                </base-input>
                            </div>
                            <div class="login-input-wrapper">
                                <base-input alternative
                                            type="password"
                                            placeholder="Password"
                                            addon-left-icon="lock-icon-class"
                                            v-model="password" 
                                            name="password"
                                            >
                                </base-input>
                            </div>
                            <div class="text-center">
                                <base-button type="primary" v-on:click="handleSubmit" class="my-4 login-button">SIGN IN</base-button>
                            </div>
                            <div class="text-center">
                                <router-link to="/register" role="button">
                                    <base-button type="neutral" class="my-4 login-button">CREATE ACCOUNT</base-button>
                                </router-link>
                            </div>
                            <div class="text-center">
                                <a href="#" class="text-light">
                                    <small>Forgot password?</small>
                                </a>
                            </div>
                        </template>
                    </card>
                </div>
            </div>
        </div>
    </section>
</template>
<script>
export default {
    data () {
        return {
            username: '',
            password: '',
            submitted: false
        }
    },
    computed: {
        loggingIn () {
            return this.$store.state.authentication.status.loggingIn;
        }
    },
    created () {
        // reset login status
        this.$store.dispatch('authentication/logout');
    },
    methods: {
        handleSubmit (e) {
            this.submitted = true;
            const { username, password } = this;
            const { dispatch } = this.$store;
            if (username && password) {
                dispatch('authentication/login', { username, password });
            }
        }
    }
};
</script>
<style>
.col-adjust-up {
    margin-top: -50px;
}
</style>
