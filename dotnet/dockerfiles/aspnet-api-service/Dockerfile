FROM docker.io/buildpack-deps:trusty-scm

RUN bash -c "\
	apt-get -qqy update && apt-get -qqy upgrade && \
	apt-get -y install git make automake libtool libunwind8 libicu52 && \
	apt-get clean && rm -rf /var/lib/apt/lists/* /tmp/* /var/tmp/*"

ENV LIBUV_VERSION "1.8.0"
RUN bash -c "\
	git clone https://github.com/libuv/libuv /tmp/libuv && \
	cd /tmp/libuv && \
	git checkout v${LIBUV_VERSION} && \
	sh autogen.sh && ./configure && make && make install && \
	rm -rf /usr/local/src/libuv-v${LIBUV_VERSION} && \
	rm -rf /tmp/libuv && \
	ldconfig"

ADD . /opt/polykube
WORKDIR /opt/polykube/
CMD bash -c "./publish/Polykube.Api"
