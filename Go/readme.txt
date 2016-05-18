
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

	comment doit-on stocker pour accélérer les réponses ?????
	Contraintes : 
	- minimiser le nb de requetes à Redis
	- simplifier le calcul sur les données récupérées  --> peut-il être fait avec LUA ?
			local count = redis.call("GET", KEYS[1]..'_COUNT')
			local total = redis.call("GET", KEYS[1]..'_TOTAL')
			if not count or not total then
			    return 0
			else
			    local avg = tonumber(total)/tonumber(count)
			    return tostring(avg)
			end	
	- solutions :
		on pourrait pre-calculer la synthese avec une clé sur le timestamp et le type de sensor
		on aurait toutes les valeurs sur ce timestamp
		il faudrait ensuite faire le calcul du min / max / medium coté serveur
	  le pb est que dans ce cas, on va devoir faire un grand nombre de requête (1 pour chaque milliseconde) ... pas top.
	  on pourrait faire un push des mesures sur une seconde donnée.
	  on divise alors par 1000 le nb de requête à Redis.

Est-il possible de résoudre ce probleme du nb de requete ? 
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
		sensorType:	integer			<----- catégorisation sur cette donnée
		minValue: integer			<----- comment les précalculer ? si on trie, on pourrait l'avoir ?
		maxValue: integer			<----- comment les précalculer ? si on trie, on pourrait l'avoir ? 
		mediumValue: integer		<----- comment les précalculer ?   somme de toutes les valeurs divisées par le nombre de valeurs
	}
]



structure cible ? 
	clé sur une seconde donnée
	valeur de type liste contenant tous les elements liés à cette seconde (inclusion / exclusion ?)

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


synthese par sensor type --> a ajouter dans la clé

on souhaite obtenir une synthèse sur un nombre de secondes données --> pré-calculer la synthèse pour chaque seconde  --> a ajouter dans la clé
du coup, comment récupérer d'un seul coup ou en parallèle les N synthèses pour la période demandée ?
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

- déclaration des path : on s'en fout, ca marche tres bien comme ca en differneciant get et post
- on n'arrive pas a récuperer la valeur depuis redis ... l'a t'on bien stockée ? pas envoyé de la bonne facon (il faut utiliser le body et non pas les headers de la requete)
- récupérer les données de la requete, les structurer pour alimenter redis
- persistance redis automatique
- structure des données à affiner pour redis en simplifiant la partie statistique
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


