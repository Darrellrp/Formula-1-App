FROM node:18-alpine3.15 AS build-env
WORKDIR /app

# Copy package.json
COPY package.json ./

# Install npm packages
RUN npm i

# Copy everything
COPY . ./

# Build and publish a prod release
RUN npm run build:prod

# Build runtime image
FROM nginx:stable
WORKDIR /var/www

# Change permission
RUN chmod 755 /var/www

# Copy build-env
COPY --from=build-env /app/dist .

# ENTRYPOINT ["exec nginx -g 'daemon off"]
CMD ["/usr/sbin/nginx", "-g", "daemon off;"]
