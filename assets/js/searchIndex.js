
var camelCaseTokenizer = function (obj) {
    var previous = '';
    return obj.toString().trim().split(/[\s\-]+|(?=[A-Z])/).reduce(function(acc, cur) {
        var current = cur.toLowerCase();
        if(acc.length === 0) {
            previous = current;
            return acc.concat(current);
        }
        previous = previous.concat(current);
        return acc.concat([current, previous]);
    }, []);
}
lunr.tokenizer.registerFunction(camelCaseTokenizer, 'camelCaseTokenizer')
var searchModule = function() {
    var idMap = [];
    function y(e) { 
        idMap.push(e); 
    }
    var idx = lunr(function() {
        this.field('title', { boost: 10 });
        this.field('content');
        this.field('description', { boost: 5 });
        this.field('tags', { boost: 50 });
        this.ref('id');
        this.tokenizer(camelCaseTokenizer);

        this.pipeline.remove(lunr.stopWordFilter);
        this.pipeline.remove(lunr.stemmer);
    });
    function a(e) { 
        idx.add(e); 
    }

    a({
        id:0,
        title:"SvnTool",
        content:"SvnTool",
        description:'',
        tags:''
    });

    a({
        id:1,
        title:"SvnAliases",
        content:"SvnAliases",
        description:'',
        tags:''
    });

    a({
        id:2,
        title:"SvnKind",
        content:"SvnKind",
        description:'',
        tags:''
    });

    a({
        id:3,
        title:"SvnAddSettings",
        content:"SvnAddSettings",
        description:'',
        tags:''
    });

    a({
        id:4,
        title:"SvnDeleter",
        content:"SvnDeleter",
        description:'',
        tags:''
    });

    a({
        id:5,
        title:"SvnRemoteSettings",
        content:"SvnRemoteSettings",
        description:'',
        tags:''
    });

    a({
        id:6,
        title:"SvnInfo",
        content:"SvnInfo",
        description:'',
        tags:''
    });

    a({
        id:7,
        title:"SvnCheckoutResult",
        content:"SvnCheckoutResult",
        description:'',
        tags:''
    });

    a({
        id:8,
        title:"ISvnClient",
        content:"ISvnClient",
        description:'',
        tags:''
    });

    a({
        id:9,
        title:"SvnLineStyle",
        content:"SvnLineStyle",
        description:'',
        tags:''
    });

    a({
        id:10,
        title:"SvnExporter",
        content:"SvnExporter",
        description:'',
        tags:''
    });

    a({
        id:11,
        title:"SvnCredentials",
        content:"SvnCredentials",
        description:'',
        tags:''
    });

    a({
        id:12,
        title:"SvnSettings",
        content:"SvnSettings",
        description:'',
        tags:''
    });

    a({
        id:13,
        title:"SvnCheckoutSettings",
        content:"SvnCheckoutSettings",
        description:'',
        tags:''
    });

    a({
        id:14,
        title:"SvnInfoSettings",
        content:"SvnInfoSettings",
        description:'',
        tags:''
    });

    a({
        id:15,
        title:"SvnInfoResult",
        content:"SvnInfoResult",
        description:'',
        tags:''
    });

    a({
        id:16,
        title:"SvnAdder",
        content:"SvnAdder",
        description:'',
        tags:''
    });

    a({
        id:17,
        title:"SvnDepth",
        content:"SvnDepth",
        description:'',
        tags:''
    });

    a({
        id:18,
        title:"SvnExportSettings",
        content:"SvnExportSettings",
        description:'',
        tags:''
    });

    a({
        id:19,
        title:"SvnExportResult",
        content:"SvnExportResult",
        description:'',
        tags:''
    });

    a({
        id:20,
        title:"SvnCheckouter",
        content:"SvnCheckouter",
        description:'',
        tags:''
    });

    a({
        id:21,
        title:"SvnDeleteSettings",
        content:"SvnDeleteSettings",
        description:'',
        tags:''
    });

    y({
        url:'/Cake.Svn/api/Cake.Svn/SvnTool_1',
        title:"SvnTool<TSettings>",
        description:""
    });

    y({
        url:'/Cake.Svn/api/Cake.Svn/SvnAliases',
        title:"SvnAliases",
        description:""
    });

    y({
        url:'/Cake.Svn/api/Cake.Svn/SvnKind',
        title:"SvnKind",
        description:""
    });

    y({
        url:'/Cake.Svn/api/Cake.Svn.Add/SvnAddSettings',
        title:"SvnAddSettings",
        description:""
    });

    y({
        url:'/Cake.Svn/api/Cake.Svn.Delete/SvnDeleter',
        title:"SvnDeleter",
        description:""
    });

    y({
        url:'/Cake.Svn/api/Cake.Svn/SvnRemoteSettings',
        title:"SvnRemoteSettings",
        description:""
    });

    y({
        url:'/Cake.Svn/api/Cake.Svn.Info/SvnInfo',
        title:"SvnInfo",
        description:""
    });

    y({
        url:'/Cake.Svn/api/Cake.Svn.Checkout/SvnCheckoutResult',
        title:"SvnCheckoutResult",
        description:""
    });

    y({
        url:'/Cake.Svn/api/Cake.Svn/ISvnClient',
        title:"ISvnClient",
        description:""
    });

    y({
        url:'/Cake.Svn/api/Cake.Svn/SvnLineStyle',
        title:"SvnLineStyle",
        description:""
    });

    y({
        url:'/Cake.Svn/api/Cake.Svn.Export/SvnExporter',
        title:"SvnExporter",
        description:""
    });

    y({
        url:'/Cake.Svn/api/Cake.Svn/SvnCredentials',
        title:"SvnCredentials",
        description:""
    });

    y({
        url:'/Cake.Svn/api/Cake.Svn/SvnSettings',
        title:"SvnSettings",
        description:""
    });

    y({
        url:'/Cake.Svn/api/Cake.Svn.Checkout/SvnCheckoutSettings',
        title:"SvnCheckoutSettings",
        description:""
    });

    y({
        url:'/Cake.Svn/api/Cake.Svn.Info/SvnInfoSettings',
        title:"SvnInfoSettings",
        description:""
    });

    y({
        url:'/Cake.Svn/api/Cake.Svn.Info/SvnInfoResult',
        title:"SvnInfoResult",
        description:""
    });

    y({
        url:'/Cake.Svn/api/Cake.Svn.Add/SvnAdder',
        title:"SvnAdder",
        description:""
    });

    y({
        url:'/Cake.Svn/api/Cake.Svn/SvnDepth',
        title:"SvnDepth",
        description:""
    });

    y({
        url:'/Cake.Svn/api/Cake.Svn.Export/SvnExportSettings',
        title:"SvnExportSettings",
        description:""
    });

    y({
        url:'/Cake.Svn/api/Cake.Svn.Export/SvnExportResult',
        title:"SvnExportResult",
        description:""
    });

    y({
        url:'/Cake.Svn/api/Cake.Svn.Checkout/SvnCheckouter',
        title:"SvnCheckouter",
        description:""
    });

    y({
        url:'/Cake.Svn/api/Cake.Svn.Delete/SvnDeleteSettings',
        title:"SvnDeleteSettings",
        description:""
    });

    return {
        search: function(q) {
            return idx.search(q).map(function(i) {
                return idMap[i.ref];
            });
        }
    };
}();
