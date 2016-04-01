FROM private-repo.microsoft.com/mssql-private-preview/mssql-server:latest

# force accept sql server eula
ENV ACCEPT_EULA Y

# override this in the PodSpec to point at a secret
ENV SA_PASSWORD password

# where does this put it's storage? need to mount a private volume there first
