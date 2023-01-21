const vueTable = new Vue({
  el: '#table',
  data: {
   api_url: 'https://localhost:5001',
   data: "Loading...",
   columns: ""
  },
  created: function() {
    axios.get(this.api_url + '/api/circuits').then(response => {
      var self = this;
      this.data = response.data;
      this.columns = Object.keys(this.data[0]);

      var connection = new signalR.HubConnectionBuilder().withUrl(this.api_url + '/signalr').build();

      connection.on("updateCircuit", function (entity) {
        self.data.push(entity);
        console.log(entity);
      });

      connection.start().then(function () {
        console.log('Started Signal R...');
      }).catch(function (err) {
          return console.error(err.toString());
      });

    });
  },
  // mounted: function() {
  //  // this.display = 'wefewfw';
  // }


})
