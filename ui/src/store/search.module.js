import { searchService } from '../services/search.service';

export const search = {
    namespaced: true,
    state: {
        all: {}
    },
    actions: {
        getAll({ commit }) {
            commit('getAllRequest');

            searchService.getAll()
                .then(
                    search => commit('getAllSuccess', search),
                    error => commit('getAllFailure', error)
                );
        }
    },
    mutations: {
        getAllRequest(state) {
            state.all = { loading: true };
        },
        getAllSuccess(state, search) {
            state.all = { items: searh };
        },
        getAllFailure(state, error) {
            state.all = { error };
        }
    }
}