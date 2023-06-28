FROM mcr.microsoft.com/dotnet/core/sdk:3.1

COPY bin/Release/netcoreapp3.1 /app

ENV MAX_STOPWATCHES 5

VOLUME /interface

CMD ["dotnet", "app/StopWatch.dll"]
