# Icebox
Icebox is load balancing web service that features a dynamic http gateway, reverse-proxy gateway handling, gateway redirection, customizable load distribution methods, and more.

![Version](https://img.shields.io/badge/Version-Pre%20Release-orange.svg)

## Installation Guide

### Deployment
To install, first download the latest release [here](https://github.com/GuyARoss/Icebox/releases). The source zip is a published version of icebox core web. So after it is extracted, just upload to an iis instance.

### Development
Clone the package, open the main .sln within the src directory and develop. Please note Icebox makes use requires .NET framework 4.6.2 [found here](https://www.microsoft.com/en-us/download/details.aspx?id=53344).

------

## Basic Usage
For advanced usage, please refer to the wiki [here](https://github.com/GuyARoss/Icebox/wiki).


### Services
Services describe a uniform service to maintain consistency between server nodes within clusters, as well as differentiating between cluster instances.

A single server can have any amount of services, usage does not need to be known to registry a service either.

Service Registry is required for node & cluster usage.

#### Service Model
- __Id__: uuid
- __Name__ : name of the service
- __Description__ : service description

__Example of service registry__

```curl
curl --request POST https://SERVER_URL_HERE/service/create 
--data '{"id": "2020", "name" : "service", "description" : "does stuff" }'
```

### Nodes
Nodes are individual servers running one service. Nodes can be run individually, but will omit them from gateway & load balancing services.

#### Node Model
- __Id__: uuid
- __Name__ : name
- __Cluster Id__: parent id of the cluster (null if blank)
- __Address__: http address of the node
- __Service Id__: service id of service running on the node


__Example of node registry__
```curl
curl --request POST https://SERVER_URL_HERE/service/create 
--data '{
"id": "2ufa0",
"name" : "name",
"clusterId": "id",
"address": "http://192.155.0.2:40",
"serviceId": "2020"
}'
```

### Clusters
Clusters are pool's of nodes that run one single service. The cluster gets determined from the gateway address, then balanced using the server nodes. 

#### Cluster Model
- __id__: uuid of the cluster
- __Name__: Name of the cluster
- __Max Size__: Max size of nodes in the cluster
- __Gateway__: The initial gateway used to access the cluster. 
- __Service Id__: Id of the service running on the cluster
- __Load Distributor Type__: Distribution method used for load balancing the nodes. For all types, please refer to the wiki [here](https://github.com/GuyARoss/Icebox/wiki). (This type should be the integer value of the method)
- __Gateway Type__: Gateway Type used in the gateway proxy process.

__Available Gateway Types__:
- (0) Redirect: Redirect the traffic to the node url
- (1) Proxy: Channel the traffic through the servers internal proxy 


__Example of cluster registry__
```curl
curl --request POST https://SERVER_URL_HERE/service/create 
--data '{
"id": "2ufa0",
"name" : "name",
"maxSize": 2,
"cluster": "/example",
"serviceId": "idofservice",
"loadDistributorType: 0,
"gatewayType": 0,
}'
```

### Accessing the Icebox Service
To access the icebox service, use the `gateway`. 

__Example__
Note in this example we have a pre-registered cluster with the gateway `/example`.
```curl
curl https://SERVER_URL_HERE/gateway/example
```
This calls the `/example` cluster, perform the load balancing & depending on what gateway type, either proxy or redirect the node request.

## Contributing
Feel free to contribute by opening a Pull Request or an issue thread.

Contributions are always appreciated! 

## License
Icebox is [MIT licensed](./LICENSE)
