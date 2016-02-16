FROM buildpack-deps:trusty-scm

ENV DOTNET_PACKAGE_NAME "dotnet-nightly"
ENV DOTNET_PACKAGE_VERSION "1.0.1.001246-1"
#ENV DOTNET_PACKAGE_VERSION "1.0.1.001186-1"
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

#The following extra packages will be installed:
#  autoconf autotools-dev binfmt-support binutils clang-3.5 cpp cpp-4.8 gcc
#  gcc-4.8 libasan0 libatomic1 libc-dev-bin libc6-dev libclang-common-3.5-dev
#  libclang1-3.5 libcloog-isl4 libffi-dev libgcc-4.8-dev libgmp10 libgomp1
#  libicu52 libisl10 libitm1 liblldb-3.6 libllvm3.5 libllvm3.6 libltdl-dev
#  libltdl7 liblttng-ust-ctl2 liblttng-ust0 libmpc3 libmpfr4 libobjc-4.8-dev
#  libobjc4 libpipeline1 libpython2.7 libquadmath0 libsigsegv2 libssl-dev
#  libssl-doc libstdc++-4.8-dev libtinfo-dev libtsan0 libunwind8 liburcu1
#  linux-libc-dev llvm-3.5 llvm-3.5-dev llvm-3.5-runtime m4 manpages
#  manpages-dev zlib1g-dev
#Suggested packages:
#  autoconf2.13 autoconf-archive gnu-standards autoconf-doc gettext
#  binutils-doc gnustep gnustep-devel clang-3.5-doc cpp-doc gcc-4.8-locales
#  gcc-multilib automake1.9 flex bison gdb gcc-doc gcc-4.8-multilib gcc-4.8-doc
#  libgcc1-dbg libgomp1-dbg libitm1-dbg libatomic1-dbg libasan0-dbg
#  libtsan0-dbg libquadmath0-dbg glibc-doc libtool-doc libstdc++-4.8-doc
#  automaken gfortran fortran95-compiler gcj-jdk llvm-3.5-doc make-doc
#  man-browser
#The following NEW packages will be installed:
#  autoconf automake autotools-dev binfmt-support binutils clang-3.5 cpp
#  cpp-4.8 dotnet-nightly gcc gcc-4.8 libasan0 libatomic1 libc-dev-bin
#  libc6-dev libclang-common-3.5-dev libclang1-3.5 libcloog-isl4 libffi-dev
#  libgcc-4.8-dev libgmp10 libgomp1 libicu52 libisl10 libitm1 liblldb-3.6
#  libllvm3.5 libllvm3.6 libltdl-dev libltdl7 liblttng-ust-ctl2 liblttng-ust0
#  libmpc3 libmpfr4 libobjc-4.8-dev libobjc4 libpipeline1 libpython2.7
#  libquadmath0 libsigsegv2 libssl-dev libssl-doc libstdc++-4.8-dev
#  libtinfo-dev libtool libtsan0 libunwind8 liburcu1 linux-libc-dev llvm-3.5
#  llvm-3.5-dev llvm-3.5-runtime m4 make manpages manpages-dev zlib1g-dev
