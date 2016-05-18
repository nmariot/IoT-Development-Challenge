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
    "encoding/json"
    "io/ioutil"
)

var client *redis.Client

// http://json2struct.mervine.net/
type JsonPost struct {
	id         string 
	iimestamp  string
	sensorType int
	value      int
}

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
		/*	    
	    body, err := ioutil.ReadAll(r.Body)
	    if err != nil {
	        panic(err)
	    } else {
		    fmt.Println("post call : " + string(body))
		    var myJson JsonPost
		    json.Unmarshal(body, &myJson)
		    fmt.Printf("Results: %v\n", myJson)
	    	err2 := client.Set(myJson.ID, body, 0).Err()
		    if err2 != nil {
		        panic(err2)
		    } else {
			    fmt.Fprintf(w, "Done")
		    }
	    }
		*/

	    fmt.Println("post call")
	    var myJson JsonPost
		err2 := json.NewDecoder(r.Body).Decode(&myJson)
	    if err2 != nil {
	    fmt.Println("decode error")
	        panic(err2)
	    } else {
		    fmt.Printf("Results: %v\n", myJson)
	    	err3 := client.Set(myJson.id, "test", 0).Err()
		    if err3 != nil {
		        panic(err3)
		    } else {
			    fmt.Fprintf(w, "Done")
		    }
	    }

		/*	    
	    var myJson JsonPost
	    err1 := json.NewDecoder(r.Body).Decode(&myJson)
	    if err1 != nil {
	        panic(err1)
	    } else {
	    	err2 := client.Set(myJson.ID, r.Body, 0).Err()
		    if err2 != nil {
		        panic(err2)
		    } else {
			    fmt.Fprintf(w, "Done")
		    }
	    }
	    */
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

