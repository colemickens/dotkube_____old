FROM docker.io/postgres:9.5.1

# override this in the PodSpec to point at a secret
ENV POSTGRES_PASSWORD password

# where does this put it's storage? need to mount a private volume there first
