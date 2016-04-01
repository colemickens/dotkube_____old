FROM nginx:1.9.12

ADD dockerfiles/aspnet-nginx/default.template /etc/nginx/conf.d/default.template

RUN bash -c "envsubst < /etc/nginx/conf.d/default.template > /etc/nginx/conf.d/default.conf && nginx -g 'daemon off;'"
