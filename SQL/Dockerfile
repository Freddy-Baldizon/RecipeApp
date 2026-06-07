FROM mcr.microsoft.com/mssql/server:2025-latest

ENV ACCEPT_EULA=Y
ENV MSSQL_SA_PASSWORD=MiClaveSegura123*

COPY RecipeAppDB.sql /RecipeAppDB.sql
COPY init.sh /init.sh

USER root
RUN chmod +x /init.sh
USER mssql

CMD ["/bin/bash", "/init.sh"]