FROM ubuntu:15.04

ENV HOME /root

RUN bash -c "\
    apt-get update && \
    apt-get -qqy install \
        vim unzip procps git libunwind8 libssl-dev libcurl4-openssl-dev \
        build-essential libtool autoconf automake libtool gettext \
        libcurl3-dev zlib1g libicu-dev libicu52 && \
    apt-get clean && rm -rf /var/lib/apt/lists/* /tmp/* /var/tmp/*"

RUN bash -c "\
    git clone https://github.com/libuv/libuv /tmp/libuv && \
    cd /tmp/libuv && \
    git checkout v1.7.5 && \
    sh autogen.sh && ./configure && make && make install && \
    rm -rf /usr/local/src/libuv-v1.7.5 && \
    rm -rf /tmp/libuv && \
    ldconfig"

RUN bash -c "\
    curl -sSL https://raw.githubusercontent.com/aspnet/Home/dev/dnvminstall.sh | DNX_BRANCH=dev sh; \
    source ~/.dnx/dnvm/dnvm.sh; \
    dnvm install latest -u -r coreclr -alias coreclr-latest ; \
    dnvm alias default coreclr-latest; \
    dnvm use default; \
    echo \"source ~/.dnx/dnvm/dnvm.sh\" >> /root/.profile"

EXPOSE 8000
