FROM ubuntu

RUN apt-get -y update

RUN apt-get -y upgrade

RUN apt-get -y install nginx

RUN apt-get -y install php-fpm

COPY www /var/www/html
COPY default /etc/nginx/sites-available/default

EXPOSE 80

CMD /usr/sbin/php-fpm7.4 && /usr/sbin/nginx && tail -f /dev/null