<template>
    <header class="header-global">
        <base-nav class="navbar-main" transparent type="" effect="light" expand>
            <router-link slot="brand" class="navbar-brand mr-lg-5" to="/">
                <img src="img/logo.png" alt="logo">
            </router-link>

            <div class="row" slot="content-header" slot-scope="{closeMenu}">
                <div class="col-6 collapse-brand">
                    <router-link to="/">
                        <img src="img/logo.png">
                    </router-link>
                </div>
                <div class="col-6 collapse-close">
                    <close-button @click="closeMenu"></close-button>
                </div>
            </div>

            
            <ul class="navbar-nav align-items-lg-center ml-lg-auto">
                
                <li class="nav-item">
                    <base-dropdown class="nav-item" menu-classes="dropdown-menu-xl">
                        <a slot="title" href="#" class="nav-link" data-toggle="dropdown" role="button">
                            <span class="menu-item-icon"><img src="img/menu_icon.png" alt="menus" /></span>
                            <span id="itemMenu" class="nav-link-inner--text nav-link-no-border">MENUS</span>
                        </a>
                    </base-dropdown>
                </li>
                <li class="nav-item d-none d-lg-block ml-lg-4">
                    <a href="" target="_blank" rel="noopener" class="btn btn-neutral ">
                        <span class="nav-link-inner--text">ADD A KITCHEN</span>
                    </a>
                </li>
                <li v-if="isLoggedIn" class="nav-item nav-item-far-right">
                    <a href="" @click="logout" class="nav-link" role="button">
                        <span class="menu-item-icon2"><img src="img/lock_icon.png" alt="login" /></span>
                        <span id="itemLogin" class="nav-link-inner--text nav-link-no-border">LOGOUT</span>
                    </a>
                </li>
                <li v-if="!isLoggedIn" class="nav-item nav-item-far-right">
                    <router-link to="/login" class="nav-link" role="button">
                        <span class="menu-item-icon2"><img src="img/lock_icon.png" alt="login" /></span>
                        <span id="itemLogin" class="nav-link-inner--text nav-link-no-border">LOGIN</span>
                    </router-link>
                </li>
            </ul>
        </base-nav>
    </header>
</template>
<script>
import BaseNav from "@/components/BaseNav";
import BaseDropdown from "@/components/BaseDropdown";
import CloseButton from "@/components/CloseButton";

export default {
    components: {
    BaseNav,
    CloseButton,
    BaseDropdown
    },
    computed: {
        isLoggedIn : function(){ 
            console.log(this.$store.state.authentication.user);
            return this.$store.state.authentication.user;
        },
        user () {
            return this.$store.state.authentication.user;
        },
        users () {
            return this.$store.state.users.all;
        }
    },
    methods: {
      logout: function () {
        this.$store.dispatch('authentication/logout')
        .then(() => {
          this.$router.push('/')
        })
      }
    }
};
</script>
<style>
header {
    font-family: Poster, sans-serif;
}
</style>
