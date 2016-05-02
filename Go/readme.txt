

==> go 1.7
==> http://goswagger.io/generate/server/
==> https://github.com/nmariot/IoT-Development-Challenge.git : api-swagger.txt

https://golang.org/#
https://golang.org/doc/articles/wiki/
https://gobyexample.com/
https://gobyexample.com/writing-files

----------------------------------------------------------------------------------------------------------
A faire :

- comment utiliser le client redis pour ajouter des données
- récupérer les données de la requete, les structurer pour alimenter redis
- persistance redis
- appels redis
- structure des données à affiner pour redis en simplifiant la partie statistique
- faire test de perf avec le swagger
- comment compiler Go pour linux ?
- 




----------------------------------------------------------------------------------------------------------

http://localhost:8080/


----------------------------------------------------------------------------------------------------------
https://github.com/go-redis/redis
	go get gopkg.in/redis.v3

go get -u github.com/nsf/gocode
D:\outils\Go\wrk\pkg\windows_amd64\golang.org\x\tools\oracle.a


services.msc -> Redis -> Restart
redis-server.exe redis.windows.conf
port 6379

----------------------------------------------------------------------------------------------------------

D:\outils\redis>redis-cli ping
	PONG
set mykey somevalu


----------------------------------------------------------------------------------------------------------
go get golang.org/x/tools/oracle


go env
	set GOARCH=amd64
	set GOBIN=
	set GOEXE=.exe
	set GOHOSTARCH=amd64
	set GOHOSTOS=windows
	set GOOS=windows
	set GOPATH=D:\outils\Go\wrk
	set GORACE=
	set GOROOT=D:\outils\Go
	set GOTOOLDIR=D:\outils\Go\pkg\tool\windows_amd64
	set GO15VENDOREXPERIMENT=1
	set CC=gcc
	set GOGCCFLAGS=-m64 -mthreads -fmessage-length=0
	set CXX=g++
	set CGO_ENABLED=1


