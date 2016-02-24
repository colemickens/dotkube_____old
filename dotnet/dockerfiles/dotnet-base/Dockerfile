FROM buildpack-deps:trusty-scm

ENV DOTNET_PACKAGE_NAME "dotnet-nightly"
ENV DOTNET_PACKAGE_VERSION "1.0.1.001606-1"
RUN bash -c "\
	echo \"deb [arch=amd64] http://apt-mo.trafficmanager.net/repos/dotnet/ trusty main\" > /etc/apt/sources.list.d/dotnetdev.list && \
	apt-key adv --keyserver apt-mo.trafficmanager.net --recv-keys 417A0893 && \
	apt-get -y update && \
	apt-get -y install git make automake libtool ${DOTNET_PACKAGE_NAME}=${DOTNET_PACKAGE_VERSION} && \
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
