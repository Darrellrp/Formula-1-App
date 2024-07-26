#!/bin/bash

bash apply_db_migrations.sh --env
bash seed_mysql_db.sh --env
