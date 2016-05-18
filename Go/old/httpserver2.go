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
    "time"
    "strconv"
)

var client *redis.Client

// http://json2struct.mervine.net/
type JsonPost struct {
	ID         string `json:"id"`
	Timestamp  string `json:"timestamp"`
	SensorType int    `json:"sensorType"`
	Value      int    `json:"value"`
}

func testfun() string {
	testvar := "test"
    return testvar
}

func getdata(keyTime int64) []JsonPost {
	s := strconv.FormatInt(keyTime, 10)
	slicesJsonPost := make([]JsonPost, 0)
	fmt.Println("getdata for ", s)
	val, err := client.LRange(s, 0, -1).Result()
    if err != nil {
        panic(err)
    } else {
	    
	    for i := 0; i < len(val); i++ {
	    	var myJson JsonPost
	    	tb := []byte(val[i])
			err1 := json.Unmarshal(tb, &myJson)
		    if err1 != nil {
		        panic(err1)
		    } else {
			    fmt.Printf("Results: %v\n", myJson)
				slicesJsonPost := append(slicesJsonPost, myJson)
		    }
	    }
    }
    return slicesJsonPost
}

func handler(w http.ResponseWriter, r *http.Request) {
	
	// recuperation des synthesis
	if r.Method == "GET" {
		// TODO a finir ...
	    fmt.Println("get call")
	    timestamp := r.URL.Query().Get("timestamp")
	    duration := r.URL.Query().Get("duration")
	    currentimestamp, err := time.Parse(time.RFC3339,  timestamp)
		if err != nil {
		    panic(err)
		} else {
			// il faut creer la liste des secondes que l'on doit recuperer
			initialTime := currentimestamp.Unix()
			iduration, err2 := strconv.Atoi(duration)
			if err2 != nil {
			    panic(err2)
			} else {
				// on initialise un tableau des donnees correspondantes
				// slicesJsonPost := make([]JsonPost, 1)
				_ = getdata(initialTime)
				
				for j := 1; j <= iduration; j++ {
					initialTime = initialTime + 1
					_ = getdata(initialTime)
			        // slicesKey := append(slicesKey, initialTime)
			    }
				// fmt.Println("set:", slicesKey)
				
				
				
			    // TODO il faut recuperer les donnees
	
				// TODO faire le parsing du json pour calculer les avg, max, min ...
	
				// TODO calculer les avg, max, min ...
				
				
				fmt.Fprintf(w, "Done")
			}
			
			
		}
	    
	    
	    
    // ajout de donnees
	} else if r.Method == "POST" {
	    fmt.Println("post call")
	    body, err := ioutil.ReadAll(r.Body)
	    if err != nil {
	        panic(err)
	    } else {
		    fmt.Println("decode data : " + string(body))
		    var myJson JsonPost
		    err2 := json.Unmarshal(body, &myJson)
		    if err2 != nil {
		        panic(err2)
		    } else {
			    fmt.Printf("Results: %v\n", myJson.ID)
			    
				currentimestamp, err3 := time.Parse(time.RFC3339,  myJson.Timestamp)
				if err3 != nil {
				    panic(err3)
				} else {
					// on cree une cle sur les secondes epoch
					secs := strconv.FormatInt(currentimestamp.Unix(), 10)
				    fmt.Println("currentimestamp : " + secs)
			    	err4 := client.LPush(secs, string(body)).Err()
				    if err4 != nil {
				        panic(err4)
				    } else {
					    fmt.Fprintf(w, "Done")
				    }
				}
		    }
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

