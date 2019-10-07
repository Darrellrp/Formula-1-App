const vueSidebar = new Vue({
  el: '#accordionSidebar',
  data: {
   api_url: 'https://localhost:5001/api',
   endpoints: "Loading..."
  },
  created: function() {
    axios.get(this.api_url).then(response => {
      this.endpoints = response.data.endpoints;    
    });
  },
  // mounted: function() {
  //  // this.display = 'wefewfw';
  // }


})
