const vueTable = new Vue({
  el: '#table',
  data: {
   api_url: 'https://localhost:44348',
   entity: '',
   columns: ''
  },
  mounted: function() {
    this.entity = location.pathname.substring(1);
    this.loadTable();
    this.connectToSocket();
  },
  methods: {
    loadTable() {
      var self = this;

      // Initialize datatable
      $(document).ready(function() {
        axios.get(self.api_url + '/api/' + self.entity).then(response => {
          var data = response.data;
          var columns = Object.keys(data[0]);

          var column_config = self.generateColumns(columns);

          self.table = $('#dataTable').DataTable({
            data: data,
            columns: column_config
          });

        }).catch(function(error) {
          window.location.replace('/404.html');
          console.log(error)
        });

      });

    },

    connectToSocket() {
      var self = this;
      var connection = new signalR.HubConnectionBuilder().withUrl(this.api_url + '/signalr').build();

      connection.on("addCircuit", function (entity) {
        var rowNode = self.table.row.add(entity).draw().node();
        // $(rowNode).css( 'color', 'red' ).animate( { color: 'black' } );
        new PNotify({
          title: 'Create Notification',
          text: entity.name + ' has just been added',
          type: 'success'
        });
        console.log(entity);
      });

      connection.on("updateCircuit", function (entity) {
        self.table.fnUpdate(entity, entity.id)
        console.log(entity);
      });

      connection.on("removeCircuit", function (entityId) {
        self.table.fnDeleteRow(entityId);
        console.log(entityId);
      });

      connection.start().then(function () {
        console.log('Started Signal R...');
      }).catch(function (err) {
          return console.error(err.toString());
      });
    },

    generateColumns(columns) {
      var config = [];

      columns.forEach(function(column) {
        var row = { title: column, data: column };
        config.push(row);
      });

      return config;
    }

  }
})
