# MicroserviceDemo
Dot Net Core 微服务例子；采用Ocelot实现服务网关，IdentityServer4实现认证，CAP实现分布式最终一致性，实现了Ocelot网关Redis缓存的示例。

微服务内部采用领域模型驱动设计，实现了接口日志、权限控制、多租户支持、软删除支持、读写分离支持等功能。

数据库用Postgresql，缓存用Redis，消息队列用RabbitMQ。

其他使用的组件包括CSRedis、Swaager、MediatR(中介者模式)、Automapper、Nlog等。

项目参考了EShop； 分为商品浏览服务，订单服务和库存服务三个微服务。

项目结构如下：
