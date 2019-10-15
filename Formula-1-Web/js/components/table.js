const vueTable = new Vue({
  el: '#table',
  data: {
   api_url: 'https://localhost:44348',
   entity: '',
   columns: ''
  },
  mounted: function() {
    this.uri = location.pathname.substring(1);
    this.loadTable();
  },
  methods: {
    loadTable() {
      var self = this;

      // Initialize datatable
      $(document).ready(function() {
        axios.get(self.api_url + '/api/' + self.uri).then(response => {
          var meta = response.data.meta;
          var data = response.data.data;

          self.entity = meta.type;

          var columns = Object.keys(data[0]);
          var column_config = self.generateColumns(columns);

          self.table = $('#dataTable').DataTable({
            data: data,
            columns: column_config
          });

        }).then(value => {
          self.connectToSocket();
        })
        .catch(function(error) {
          // window.location.replace('/404.html');
          console.log(error)
        });

      });

    },

    connectToSocket() {
      var self = this;

      $(document).ready(function() {
        var connection = new signalR.HubConnectionBuilder().withUrl(self.api_url + '/signalr').build();
        connection.on("add" + self.entity, function (entity) {
          var rowNode = self.table.row.add(entity).draw().node();
          // $(rowNode).css( 'color', 'red' ).animate( { color: 'black' } );

          new PNotify({
            title: 'Create Notification',
            text: `${self.entity}-${entity.id} has just been created`,
            type: 'success'
          });

          console.log(entity);
        });

        connection.on("update" + self.entity, function (entity) {
          // Remove column
          self.table.rows((idx, data, node) => {
            return data.id === entity.id;
          })
          .remove()
          .draw();

          var rowNode = self.table.row.add(entity).draw().node();
          // $(rowNode).css( 'color', 'red' ).animate( { color: 'black' } );

          new PNotify({
            title: 'Update Notification',
            text: `${self.entity}-${entity.id} has just been updated`,
            type: 'warning'
          });

          console.log(entity);
        });

        connection.on("remove" + self.entity, function (entityId) {
          // Remove column
          self.table.rows((idx, data, node) => {
            return data.id === entityId;
          })
          .remove()
          .draw();

          new PNotify({
            title: 'Delete Notification',
            text: `${self.entity}-${entityId} has just been deleted`,
            type: 'error'
          });

          console.log(entityId);
        });

        connection.start().then(function () {
          console.log('Started Signal R...');
        }).catch(function (err) {
            return console.error(err.toString());
        });
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
