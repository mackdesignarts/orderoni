<template>
    <div class="search-wrapper">
        <div class="row">
            <div class="col-3">
                <router-link to="menus">
                    <span class="big-red-text-block">EAT</span>
                </router-link>
            </div>
            <div class="col-9 heading-1 search-heading">
                Find local chefs, restaurants, caterers and order online.
            </div>
        </div>
        <div class="search-input-wrapper">
            <div class="row" >
                <div class="col-sm-7 search-input-box">
                    <base-input alternative
                                placeholder="Enter your location to see local menus"
                                addon-left-icon="search-icon-class"
                                v-model="search" 
                                name="search"
                                >
                    </base-input>
                </div>
                <div class="col-sm-4">
                    <base-button type="primary" v-on:click="handleSubmit" class="my-4 login-button search-button arrow-button">FIND FOOD</base-button>
                </div>
            </div>
        </div>
    </div>
</template>
<script>
export default {
    data () {
        return {
            search: '',
            submitted: false
        }
    },
    computed: {
        
    },
    created () {
        
    },
    methods: {
        handleSubmit (e) {
            this.submitted = true;
            const { search } = this;
            console.log(search);
        }
    }
};
</script>
<style>
</style>
