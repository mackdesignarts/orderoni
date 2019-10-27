import config from '../../config';

export const searchService = {
    search
};

function search(param) {
    const requestOptions = {
        method: 'POST',
        headers: { 'Content-Type': 'application/json' },
        body: JSON.stringify({ param })
    };

    return fetch(`${config.apiUrl}/search`, requestOptions)
        .then(handleResponse)
        .then(response => {
            if (response.success) {
                localStorage.setItem('searchResponse', JSON.stringify(response));
            }

            return response;
        });
}

function handleResponse(response) {
    return response.text().then(text => {
        const data = text && JSON.parse(text);
        if (!response.ok) {
            if (response.status === 401) {
                
            }

            const error = (data && data.message) || response.statusText;
            return Promise.reject(error);
        }

        return data;
    });
}