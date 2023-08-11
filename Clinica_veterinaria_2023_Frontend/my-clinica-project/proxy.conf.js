const PROXY_CONFIG = [
  {
    context:['/api'],
    target:'http://locahost:5272/',
    secure:false,
    logLevel:'debug'
  }
];

module.exports = PROXY_CONFIG;
