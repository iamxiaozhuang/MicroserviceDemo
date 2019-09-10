# MicroserviceDemo
Dot Net Core 微服务例子；采用Ocelot实现服务网关，IdentityServer4实现认证，CAP实现分布式数据最终一致性。

微服务内部采用领域模型驱动设计，实现了接口日志、权限控制、多租户、软删除、读写分离等功能；实现了Ocelot网关Redis缓存的示例。

数据库用Postgresql，缓存用Redis，消息队列用RabbitMQ。

其他使用的组件包括Refit、CSRedis、Swaager、MediatR(中介者模式)、Automapper、Nlog等。

项目参考了EShop； 分为商品浏览(Product)服务，订单(Ordering)服务和支付(Payment)服务三个微服务。

项目结构如下：
