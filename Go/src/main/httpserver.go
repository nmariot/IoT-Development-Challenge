// mettre en place les deux services web d'écriture et de lecture
// mettre en place redis et le configurer pour persister les donnes de facon synch
// développer le client redis dans go
// pong, err := client.Ping().Result()
// fmt.Println(pong, err)
// fmt.Fprintf(w, "POST %s!", r.URL.Path[1:])
package main

import (
    "fmt"
    "net/http"
    "gopkg.in/redis.v3"
)

var client *redis.Client

func handler(w http.ResponseWriter, r *http.Request) {
    
	if r.Method == "GET" {
	    fmt.Println("get call")
    	val, err := client.Get("key").Result()
	    if err != nil {
	        panic(err)
	    } else {
		    fmt.Println("respond ", val)
	    	fmt.Fprintf(w, val)
	    }
	} else if r.Method == "POST" {
	    fmt.Println("post call")
	    val := r.FormValue("value")
    	err := client.Set("key", val, 0).Err()
	    if err != nil {
	        panic(err)
	    } else {
		    fmt.Fprintf(w, "Done")
	    }
	}
	
}

func main() {
    fmt.Println("main")
	client = redis.NewClient(&redis.Options{
        Addr:     "localhost:6379",
        Password: "", // no password set
        DB:       0,  // use default DB
    })
	pong, err := client.Ping().Result()
    fmt.Println("Redis ping : ", pong, err)
	
    fmt.Println("add handle")
    http.HandleFunc("/", handler)
    http.ListenAndServe(":8080", nil)
}

