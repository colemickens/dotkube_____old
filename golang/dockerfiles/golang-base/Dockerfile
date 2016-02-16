FROM buildpack-deps:wily-scm

RUN bash -c "\
	apt-get -y update && \
	apt-get -y install golang make && \
	apt-get clean && rm -rf /var/lib/apt/lists/* /tmp/* /var/tmp/*"
