import axios from 'axios';
let API_URL = "https://localhost:7173/api";
export function callApi(endpoint, method = 'GET', body) {
    return axios({
        method,
        url: `${API_URL}/${endpoint}`,
        data: body,
    }).catch(e => {
        console.log(e)
    })
}

// Modify your GET_ALL_TODOs function to provide type information
export function GET_ALL_TODOs(endpoint: string): Promise<ApiResponse> {
    return callApi(endpoint, 'GET');
}

export function GET_TODO_ID(endpoint, id) {
    return callApi(endpoint + "/" + id, "GET");
}
export function POST_ADD_TODO(endpoint, data) {
    return callApi(endpoint, "POST", data);
}
export function PUT_EDIT_TODO(endpoint, data) {
    return callApi(endpoint, "PUT", data);
}
export function DELETE_TODO_ID(endpoint) {
    return callApi(endpoint, "DELETE");
}
export function GET_ALL_CATEGORIES(endpoint) {
    return callApi(endpoint, "GET");
}
