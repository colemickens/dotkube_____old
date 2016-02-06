FROM gliderlabs/alpine:3.3

ENV DOTNET_PACKAGE_NAME "dotnet-nightly"
ENV DOTNET_PACKAGE_VERSION "1.0.1.001186-1"

RUN apk-install icu icu-libs icu-dev \
	wget git unzip \
	libstdc++ gcc \
	llvm llvm-libs \
	libunwind libunwind-dev \


WORKDIR /opt/dotnet-cli

RUN git clone https://github.com/dotnet/cli

WORKDIR /opt/dotnet-cli/cli

RUN apk-install bash

RUN ./build.sh
