# Base stage
FROM nginx:stable-alpine as base
WORKDIR /var/www

RUN chmod 755 /var/www

EXPOSE 80
EXPOSE 443

# Install stage
FROM node:18-alpine3.15 AS install
WORKDIR /app

COPY package.json .

RUN npm i

# Build stage
FROM install AS build
WORKDIR /app

COPY . .

RUN npm run build:prod

# Final stage
FROM base AS final
WORKDIR /var/www

COPY --from=build /app/dist .

# ENTRYPOINT ["exec nginx -g 'daemon off"]
CMD ["/usr/sbin/nginx", "-g", "daemon off;"]
