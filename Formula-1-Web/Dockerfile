FROM nginx:stable

COPY Formula-1-Web /var/www
COPY Formula-1-Web/nginx/nginx.conf /etc/nginx/conf.d/default.conf

RUN chmod 755 /var/www
