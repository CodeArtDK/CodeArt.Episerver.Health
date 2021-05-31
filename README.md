# CodeArt.Episerver.Health

A pluggable health checking service for Optimizely (Episerver). 
Consists of a UI for showing the current health of the site/instance, that will run through a series of health checks and indicate if everything is ok, if something could be optimized or if there is a problem.
In some cases the health checks can even offer to fix the problem.

Health checks can be extended by implementing the proper interface.
