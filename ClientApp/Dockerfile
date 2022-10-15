FROM node:16 AS build-env
WORKDIR /app

# Copy everything
COPY . ./

# Install npm packages
RUN npm i

# Build and publish a prod release
RUN npm run build:prod

# Build runtime image
FROM nginx:stable
WORKDIR /var/www

COPY --from=build-env /app/dist .

# Change permission
RUN chmod 755 /var/www

# ENTRYPOINT ["exec nginx -g 'daemon off"]
CMD ["/usr/sbin/nginx", "-g", "daemon off;"]