import { MockRequest } from '@delon/mock';

const list = [];
const total = 50;

for (let i = 0; i < total; i += 1) {
  list.push({
    id: i + 1,
    disabled: i % 6 === 0,
    href: 'https://ant.design',
    avatar: [
      'https://gw.alipayobjects.com/zos/rmsportal/eeHMaZBwmTvLdIwMfBpg.png',
      'https://gw.alipayobjects.com/zos/rmsportal/udxAbMEhpwthVVcjLXik.png',
    ][i % 2],
    no: `TradeCode ${i}`,
    title: `?????????????????? ${i}`,
    owner: '?????????',
    description: '??????????????????',
    callNo: Math.floor(Math.random() * 1000),
    status: Math.floor(Math.random() * 10) % 4,
    updatedAt: new Date(`2017-07-${Math.floor(i / 2) + 1}`),
    createdAt: new Date(`2017-07-${Math.floor(i / 2) + 1}`),
    progress: Math.ceil(Math.random() * 100),
  });
}

function genData(params: any) {
  let ret = [...list];
  const pi = +params.pi,
    ps = +params.ps,
    start = (pi - 1) * ps;

  if (params.no) {
    ret = ret.filter(data => data.no.indexOf(params.no) > -1);
  }

  return { total: ret.length, list: ret.slice(start, ps * pi) };
}

function saveData(id: number, value: any) {
  const item = list.find(w => w.id === id);
  if (!item) return { msg: '??????????????????' };
  Object.assign(item, value);
  return { msg: 'ok' };
}

export const USERS = {
  '/user': (req: MockRequest) => genData(req.queryString),
  '/user/:id': (req: MockRequest) => list.find(w => w.id === +req.params.id),
  'POST /user/:id': (req: MockRequest) => saveData(+req.params.id, req.body),
  '/user/current': {
    name: 'Cipchk',
    avatar:
      'https://gw.alipayobjects.com/zos/rmsportal/BiazfanxmamNRoxxVxka.png',
    userid: '00000001',
    email: 'cipchk@qq.com',
    signature: '???????????????????????????',
    title: '????????????',
    group: '????????????????????????????????????????????????????????????????????????UED',
    tags: [
      {
        key: '0',
        label: '???????????????',
      },
      {
        key: '1',
        label: '????????????',
      },
      {
        key: '2',
        label: '???~',
      },
      {
        key: '3',
        label: '??????',
      },
      {
        key: '4',
        label: '????????????',
      },
      {
        key: '5',
        label: '????????????',
      },
    ],
    notifyCount: 12,
    country: 'China',
    geographic: {
      province: {
        label: '??????',
        key: '330000',
      },
      city: {
        label: '?????????',
        key: '330100',
      },
    },
    address: 'XX???XXX??? XX ???',
    phone: '??????-??????????????????',
  },
  'POST /user/avatar': 'ok',
  'POST /login/account': (req: MockRequest) => {
    const data = req.body;
    if (
      !(data.userName === 'admin' || data.userName === 'user') ||
      data.password !== 'ng-alain.com'
    ) {
      return { msg: `Invalid username or password???admin/ng-alain.com???` };
    }
    return {
      msg: 'ok',
      user: {
        token: '123456789',
        name: data.userName,
        email: `${data.userName}@qq.com`,
        id: 10000,
        time: +new Date(),
      },
    };
  },
  'POST /register': {
    msg: 'ok',
  },
};
