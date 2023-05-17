FROM node:latest as build-stage
WORKDIR /WebClient
COPY ../../src/WebClient/package*.json /WebClient
RUN npm install
COPY ../../src/WebClient /WebClient
RUN npm run build
COPY ../../.docker/nginx/configs /nginx/conf.d

FROM nginx:latest
COPY --from=build-stage /WebClient/build/ /WebClient
COPY --from=build-stage /nginx/conf.d/gigachat.conf /etc/nginx/conf.d/default.conf