const vueSidebar = new Vue({
  el: '#accordionSidebar',
  data: {
   api_url: 'https://localhost:44348/api',
   endpoints: []
  },
  created: function() {
    axios.get(this.api_url).then(response => {
      this.endpoints = response.data.endpoints;
    });
  }

})
