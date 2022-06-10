import {createRouter, createWebHistory} from 'vue-router';

const routes = [
    {name:'home', peth:'/', redirect:'/classificator'},
    {name:'classifcator', path:'/classificator', component:()=>import('../views/Classificator.vue')},
    {name:'graph', path:'/graph', component:()=> import('../views/Graph.vue')}
];

const router = createRouter({
    history:createWebHistory(),
    routes
});

export default router;


