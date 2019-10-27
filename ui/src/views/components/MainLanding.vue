<template>
    <div class="container main-content-landing">
        <div class="row">
            <div class="col-7">
                <search></search>
            </div>
            <div class="col-4">
                <cta-main></cta-main>
            </div>
        </div>
        
    </div>    
</template>
<script>
import Search from "./Search";
import CtaMain from "./CtaMain";
export default {
    components: {
        Search,
        CtaMain
    }
}
</script>
<style scoped>

</style>