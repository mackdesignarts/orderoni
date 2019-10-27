<template>
    <div class="">
        <div class="row">
            <div class="col-3">
                <span class="big-red-text-block">EAT</span>
            </div>
            <div class="col-9 heading-1 search-heading">
                Find local chefs, restaurants, caterers and order online.
            </div>
        </div>
        <div class="row">
            <div class="search-input-wrapper">
                <base-input alternative
                            placeholder="Enter your location to see local menus"
                            addon-left-icon="search-icon-class"
                            v-model="search" 
                            name="search"
                            >
                </base-input>
            </div>
            <div class="text-center">
                <base-button type="primary" v-on:click="handleSubmit" class="my-4 login-button">FIND FOOD</base-button>
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
           
        }
    }
};
</script>
<style>
</style>
