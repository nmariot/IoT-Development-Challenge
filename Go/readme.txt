
Chalenge :

Old school

https://github.com/nmariot/IoT-Development-Challenge.git : api-swagger.txt
https://github.com/IsBena/IoT-Development-Challenge/blob/master/gatling/gatling_script.scala

----------------------------------------------------------------------------------------------------------
POST http://localhost:8080/messages
{
	"id": "12345",
	"timestamp": "2016-05-18T15:27:40.628",   // yyyy-MM-dd'T'HH:mm:ss.SSSXXX
	"sensorType": 12,
	"value": 24
}

	rpush mylist 1 2 3 4 5 "foo bar" ?

	comment doit-on stocker pour acc�l�rer les r�ponses ?????
	Contraintes : 
	- minimiser le nb de requetes � Redis
	- simplifier le calcul sur les donn�es r�cup�r�es  --> peut-il �tre fait avec LUA ?
			local count = redis.call("GET", KEYS[1]..'_COUNT')
			local total = redis.call("GET", KEYS[1]..'_TOTAL')
			if not count or not total then
			    return 0
			else
			    local avg = tonumber(total)/tonumber(count)
			    return tostring(avg)
			end	
	- solutions :
		on pourrait pre-calculer la synthese avec une cl� sur le timestamp et le type de sensor
		on aurait toutes les valeurs sur ce timestamp
		il faudrait ensuite faire le calcul du min / max / medium cot� serveur
	  le pb est que dans ce cas, on va devoir faire un grand nombre de requ�te (1 pour chaque milliseconde) ... pas top.
	  on pourrait faire un push des mesures sur une seconde donn�e.
	  on divise alors par 1000 le nb de requ�te � Redis.

Est-il possible de r�soudre ce probleme du nb de requete ? 
Search : keys *pattern* ????
	http://redis.io/commands/keys
mget : http://redis.io/commands/mget
	on recupere d'un seul coup N elements 
	KEYS sensor:temp:2015:12:02-13:??:?? > $KEYS
	MGET $KEYS
SCAN command with MATCH ?
	scan 0 match V3.0:*	



GET http://localhost:8080/messages/synthesis?timestamp=12345675432&duration=3  (en seconde)
[
	synthesis {
		sensorType:	integer			<----- cat�gorisation sur cette donn�e
		minValue: integer			<----- comment les pr�calculer ? si on trie, on pourrait l'avoir ?
		maxValue: integer			<----- comment les pr�calculer ? si on trie, on pourrait l'avoir ? 
		mediumValue: integer		<----- comment les pr�calculer ?   somme de toutes les valeurs divis�es par le nombre de valeurs
	}
]



structure cible ? 
	cl� sur une seconde donn�e
	valeur de type liste contenant tous les elements li�s � cette seconde (inclusion / exclusion ?)

SADD ?
	redis> SADD myset "Hello"
	(integer) 1
	redis> SADD myset "World"
	(integer) 1
	redis> SADD myset "World"
	(integer) 0
	redis> SMEMBERS myset
	1) "Hello"
	2) "World"


synthese par sensor type --> a ajouter dans la cl�

on souhaite obtenir une synth�se sur un nombre de secondes donn�es --> pr�-calculer la synth�se pour chaque seconde  --> a ajouter dans la cl�
du coup, comment r�cup�rer d'un seul coup ou en parall�le les N synth�ses pour la p�riode demand�e ?
	MGET key1 key2 nonexisting





----------------------------------------------------------------------------------------------------------
Gatling
Projet Gatling pour lancner les tests de perfs : 
	D:\workspaces\vsc\TMO\gatling

impossible de lancer depuis maven
encoding utf 8 obligatoire ? 

----------------------------------------------------------------------------------------------------------
PB Go :
invalid character 'i' looking for beginning of object key string  ==> structure json pas correcte

----------------------------------------------------------------------------------------------------------
==> client redis : redis desktop manager
==> go 1.7
==> http://goswagger.io/generate/server/

https://golang.org/#
https://golang.org/doc/articles/wiki/
https://gobyexample.com/
https://gobyexample.com/writing-files

----------------------------------------------------------------------------------------------------------
A faire :

- d�claration des path : on s'en fout, ca marche tres bien comme ca en differneciant get et post
- on n'arrive pas a r�cuperer la valeur depuis redis ... l'a t'on bien stock�e ? pas envoy� de la bonne facon (il faut utiliser le body et non pas les headers de la requete)
- r�cup�rer les donn�es de la requete, les structurer pour alimenter redis
- persistance redis automatique
- structure des donn�es � affiner pour redis en simplifiant la partie statistique
- faire test de perf avec le swagger
- comment compiler Go pour linux ?
- comment lancer le prg go et redis sur le raspberry ?
- elever les logs




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


