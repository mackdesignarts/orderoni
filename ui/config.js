module.exports = {
    publicPath: process.env.NODE_ENV === 'production'
    ? '/production-sub-path/'
    : '/',
    apiUrl: "https://localhost:44307/api",
  }