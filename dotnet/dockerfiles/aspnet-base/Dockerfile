FROM docker.io/buildpack-deps:trusty-scm

RUN bash -c "\
	echo \"deb [arch=amd64] http://apt-mo.trafficmanager.net/repos/dotnet/ trusty main\" > /etc/apt/sources.list.d/dotnetdev.list && \
	apt-key adv --keyserver apt-mo.trafficmanager.net --recv-keys 417A0893"

RUN bash -c "\
	apt-get update; apt-get upgrade -qqy; apt-get install -qqy git make automake libtool && \
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

ENV DOTNET_VER "1.0.0-beta-002288"
ENV DOTNET_DEV_PKG "dotnet-dev-${DOTNET_VER}"
ENV DOTNET_HOST_PKG "dotnet-host=${DOTNET_VER}-1"
RUN bash -c "\
	apt-get update; apt-get upgrade -qqy && \
	apt-get install -qqy ${DOTNET_DEV_PKG} ${DOTNET_HOST_PKG} && \
	apt-get clean && rm -rf /var/lib/apt/lists/* /tmp/* /var/tmp/*"
